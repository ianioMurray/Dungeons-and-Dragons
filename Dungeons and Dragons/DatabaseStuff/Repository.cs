using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Dungeons_and_Dragons.InteractItems;


namespace Dungeons_and_Dragons
{
    public class Repository
    {
        private string ConnectionString;
        private SqlConnection connection;

        public Repository()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Dungeons_and_Dragons.Properties.Settings.DnD_DatabaseConnectionString"].ConnectionString;
        }

        //for testing purposes 
        public Repository(string connnectionString)
        {
            ConnectionString = connnectionString;
        }

        public int SaveCharacter(Character character, ClassType characterClass)
        {
            int charId = 0;

            if (character.characterId == 0)
            {
                charId = SaveNewCharacter(character, characterClass);
            }
            else
            {
                charId = UpdateExistingCharacter(character, characterClass);
            }
            return charId;
        }

        private int SaveNewCharacter(Character character, ClassType characterClass)
        {
            string query = "INSERT INTO Character output INSERTED.ID VALUES (@Name, @Class, @Race, @Strength, @Dexterity, @Intelligence, @Wisdom, @Constitution," +
                 "@Charisma, @HitPoints, @XP, @EquippedToBody, @EquippedToRightHand, @EquippedToLeftHand)";
            using (connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@Name", character.name);
                command.Parameters.AddWithValue("@Class", (int)characterClass);
                command.Parameters.AddWithValue("@Race", (int)character.characterRace);
                command.Parameters.AddWithValue("@Strength", character.attributes[Attribute.Strength]);
                command.Parameters.AddWithValue("@Dexterity", character.attributes[Attribute.Dexterity]);
                command.Parameters.AddWithValue("@Intelligence", character.attributes[Attribute.Intelligence]);
                command.Parameters.AddWithValue("@Wisdom", character.attributes[Attribute.Wisdom]);
                command.Parameters.AddWithValue("@Constitution", character.attributes[Attribute.Constitution]);
                command.Parameters.AddWithValue("@Charisma", character.attributes[Attribute.Charisma]);
                command.Parameters.AddWithValue("@HitPoints", character.hitPoints);
                command.Parameters.AddWithValue("@XP", character.experiencePoints);
                command.Parameters.AddWithValue("@EquippedToBody", 0);
                command.Parameters.AddWithValue("@EquippedToRightHand", 0);
                command.Parameters.AddWithValue("@EquippedToLeftHand", 0);

                //gets row affected
                int characterDatabaseId = (int)command.ExecuteScalar();
                character.SetCharacterId(characterDatabaseId);
                return characterDatabaseId;
            }
        }

        private int UpdateExistingCharacter(Character character, ClassType characterClass)
        {
            int equippedBodyDataseId = SaveItemEquipped(character.equippedToBody);
            int equippedRightHandId = SaveItemEquipped(character.equippedInRightHand);
            int equippedLeftHandId = SaveItemEquipped(character.equippedInLeftHand);

            string query = "UPDATE Character SET HitPoints = @HitPoints, XP = @XP, EquippedToBody = @EquippedToBody, EquippedToRightHand = @EquippedToRightHand, " +
                "EquippedToLeftHand = @EquippedToLeftHand WHERE ID=" + character.characterId;
            using (connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@HitPoints", character.hitPoints);
                command.Parameters.AddWithValue("@XP", character.experiencePoints);
                command.Parameters.AddWithValue("@EquippedToBody", equippedBodyDataseId);
                command.Parameters.AddWithValue("@EquippedToRightHand", equippedRightHandId);
                command.Parameters.AddWithValue("@EquippedToLeftHand", equippedLeftHandId);

                //gets row affected
                command.ExecuteNonQuery();
                return character.characterId;
            }
        }

        public int SaveItemEquipped(EquipmentItems item)
        {
            int databaseId = 0;

            if (item != null)
            {
                string query1 = "INSERT INTO Equipment output INSERTED.ID VALUES (@EquipmentCategory, @EquipmentType)";
                using (connection = new SqlConnection(ConnectionString))
                using (SqlCommand command1 = new SqlCommand(query1, connection))
                {
                    connection.Open();

                    command1.Parameters.AddWithValue("@EquipmentCategory", item.category);
                    
                    if(item is Armour)
                    {
                        Armour armour = (Armour)item;
                        command1.Parameters.AddWithValue("@EquipmentType", armour.type);
                    }
                    else if (item is Weapon)
                    {
                        Weapon weapon = (Weapon)item;
                        command1.Parameters.AddWithValue("@EquipmentType", weapon.type);
                    }

                    //gets row affected
                    databaseId = (int)command1.ExecuteScalar();
                }
            }
            return databaseId;
        }


        public List<Character> LoadCharacters()
        {
            string query = "SELECT * FROM character";
            using (connection = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable characterTable = new DataTable();
                adapter.Fill(characterTable);

                List<Character> characters = new List<Character>();

                foreach (DataRow row in characterTable.Rows)
                {
                    int characterId = row.Field<int>("Id");
                    string name = row.Field<string>("Name");
                    ClassType characterClass = (ClassType)row.Field<int>("Class");
                    Race characterRace = (Race)row.Field<int>("Race");
                    Dictionary<Attribute, int> dict = new Dictionary<Attribute, int>();
                    dict.Add(Attribute.Strength, row.Field<int>("Strength"));
                    dict.Add(Attribute.Dexterity, row.Field<int>("Dexterity"));
                    dict.Add(Attribute.Intelligence, row.Field<int>("Intelligence"));
                    dict.Add(Attribute.Wisdom, row.Field<int>("Wisdom"));
                    dict.Add(Attribute.Constitution, row.Field<int>("Constitution"));
                    dict.Add(Attribute.Charisma, row.Field<int>("Charisma"));
                    int HitPoints = row.Field<int>("HitPoints");
                    int xp = row.Field<int>("XP");
                    int equippedToBody = row.Field<int>("EquippedToBody");
                    int equippedToRightHand = row.Field<int>("EquippedToRightHand");
                    int equippedToLeftHand = row.Field<int>("EquippedToLeftHand");

                    EquipmentItems bodyEquipment = null;
                    EquipmentItems rightHandEquipment = null;
                    EquipmentItems leftHandEquipment = null;

                    if (equippedToBody != 0)
                    {
                        bodyEquipment = LoadEquipment(equippedToBody);
                    }

                    if(equippedToRightHand != 0)
                    {
                        rightHandEquipment = LoadEquipment(equippedToRightHand);
                    }

                    if(equippedToLeftHand != 0)
                    {
                        leftHandEquipment = LoadEquipment(equippedToLeftHand);
                    }

                    Character character = null;

                    switch (characterClass)
                    {
                        case ClassType.Fighter:
                            {
                                character = new Fighter(name, characterRace, dict, HitPoints, xp);
                                break;
                            }
                        case ClassType.Thief:
                            {
                                character = new Thief(name, characterRace, dict, HitPoints, xp);
                                break;
                            }
                        case ClassType.MagicUser:
                            {
                                character = new MagicUser(name, characterRace, dict, HitPoints, xp);
                                break;
                            }
                        case ClassType.Cleric:
                            {
                                character = new Cleric(name, characterRace, dict, HitPoints, xp);
                                break;
                            }
                    }

                    if (bodyEquipment != null)
                    {
                        character.EquipToBody(bodyEquipment);
                    }

                    if (rightHandEquipment != null)
                    {
                       character.EquipToHand(rightHandEquipment, Hand.Right);
                    }

                    if (leftHandEquipment != null)
                    {
                        character.EquipToHand(leftHandEquipment, Hand.Left);
                    }

                    character.SetCharacterId(characterId);

                    characters.Add(character);
                }
                return characters;
            }
        }

        private EquipmentItems LoadEquipment(int equipmentId)
        {
            string query1 = "SELECT * FROM equipment where Id=" + equipmentId;
            using (SqlCommand command1 = new SqlCommand(query1, connection))
            using (SqlDataAdapter adapter1 = new SqlDataAdapter(command1))
            {
                DataTable characterTable1 = new DataTable();
                adapter1.Fill(characterTable1);

                foreach (DataRow row1 in characterTable1.Rows)
                {
                    int equipCategory = row1.Field<int>("EquipmentCategory");
                    int equipType = row1.Field<int>("EquipmentType");

                    switch(equipCategory)
                    {
                        case (int) EquipmentCategory.Armour:
                            {
                                return CreateArmour(equipType);
                            }
                        case (int)EquipmentCategory.Weapon:
                            {
                                return CreateWeapon(equipType);
                            }
                    }
                }
            }
            return null;
        }


        private EquipmentItems CreateArmour(int equipType)
        {
            switch (equipType)
            {
                case (int)ArmourType.PlateMail:
                    {
                        return new PlateMail();
                    }
                case (int)ArmourType.ChainMail:
                    {
                        return new ChainMail();
                    }
                case (int)ArmourType.LeatherArmour:
                    {
                        return new LeatherArmour();
                    }
                case (int)ArmourType.Shield:
                    {
                        return new Shield();
                    }
                default:
                    throw new Exception("Unknown Armour");
            }
        }

        private EquipmentItems CreateWeapon(int equipType)
        {
            switch (equipType)
            {
                case (int)WeaponType.Sword:
                    {
                        return new Sword();
                    }
                case (int)WeaponType.TwoHandedSword:
                    {
                        return new TwoHandedSword();
                    }
                case (int)WeaponType.ShortSword:
                    {
                        return new ShortSword();
                    }
                case (int)WeaponType.Spear:
                    {
                        return new Spear();
                    }
                case (int)WeaponType.Dagger:
                    {
                        return new NormalDagger();
                    }
                default:
                    throw new Exception("Unknown Weapon");
            }
        }
    }
}
