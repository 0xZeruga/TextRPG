using System;
using System.Collections.Generic;
using System.IO;

namespace Arena
{
    public class Game
    {
        public Player player;

        public Game()
        {
            Intro();
           
        }

        public void Intro()
        {
            Console.WriteLine("Press 1 to start a New Game");
            Console.WriteLine("Or type the name of character\nyou wish to load");
            var input = Console.ReadLine();
            if (input != "1")
            {
                LoadCharacter(input);
            }
            else
            {
                StartNewGame();
            }
        }
        
        public void LoadCharacter(string charactername)
        {
            foreach(string file in Directory.EnumerateFiles("./", charactername+"*.txt"))
            {
                string toLoad = File.ReadAllText(file);
                if(toLoad==null)
                {
                    Console.WriteLine("No Character match that name, make\n sure the character file is in the folder");
                    Intro();
                }
                Console.WriteLine(toLoad);
                LoadToGame(toLoad);
            }
            Console.ReadLine();
        }

        public void LoadToGame(string toload)
        {

        }

        public void StartNewGame()
        {
            ArenaPrompt();
            player = new Player();
            Instruction();
            Console.WriteLine("Your character's name is " + player.name);
            DisplayRaces();
            SetRace();
            DisplayClasses();
            SetClass();
            CalcInitMods(player);
            WriteToFile();
            //player = new Player();
        }

        public void WriteToFile()
        {
            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;
            PrintPlayer();
            try
            {
                ostrm = new FileStream("./"+player.name+".txt", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open Redirect.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }
            Console.SetOut(writer);
            PrintPlayer();
            Console.SetOut(oldOut);
            writer.Close();
            ostrm.Close();
            Console.WriteLine("Done");
            Console.ReadLine();
        } 

        public void PrintPlayer()
        {
            Console.WriteLine(" ________________");
            Console.WriteLine(" Name: " + player.name);
            Console.WriteLine(" Race: " + player.Race);
            Console.WriteLine(" Class: " + player.Job);
            Console.WriteLine(" ----------------");
            Console.WriteLine(" Health: " + player.Health);
            Console.WriteLine(" Level: " + player.level);
            Console.WriteLine(" Experience: " + player.experience);
            Console.WriteLine(" WeaponDamage: " + player.GetWeaponDamage());
            Console.WriteLine(" SpellDamage: " + player.GetSpellDamage());
            Console.WriteLine(" CritChance: " + player.Crit +"%");
            Console.WriteLine(" DodgeChance: " + player.Dodge+"%");
            Console.WriteLine(" Persuade: " + player.Persuade+"%");
            Console.WriteLine(" ----------------");
            Console.WriteLine(" Strength: " + player.attributes.attributes["Strength"]);
            Console.WriteLine(" Dexterity: " + player.attributes.attributes["Dexterity"]);
            Console.WriteLine(" Toughness: " + player.attributes.attributes["Toughness"]);
            Console.WriteLine(" Intellect: " + player.attributes.attributes["Intellect"]);
            Console.WriteLine(" Charisma: " + player.attributes.attributes["Charisma"]);
            Console.WriteLine(" ----------------");
            Console.WriteLine(" Smithing: " + player.skills.skills["Smithing"]);
            Console.WriteLine(" Alchemy: " + player.skills.skills["Alchemy"]);
            Console.WriteLine(" Bargain: " + player.skills.skills["Bargain"]);
            Console.WriteLine(" OneHanded: " + player.skills.skills["Onehanded"]);
            Console.WriteLine(" TwoHanded: " + player.skills.skills["Twohanded"]);
            Console.WriteLine(" Magic: " + player.skills.skills["Magic"]);
            Console.WriteLine(" ----------------");
            Console.WriteLine(" Armor: " + player.Armor);
            Console.WriteLine(" Weapon: " + player.Weapon);
            Console.WriteLine(" Gold: " + player.currencies["Gold"]);
            Console.WriteLine(" Silver: " + player.currencies["Silver"]);
            Console.WriteLine(" Copper: " + player.currencies["Copper"]);
            Console.WriteLine(" ________________");
        }


        public void Instruction()
        {
            Console.WriteLine(" _____________________________________________");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|     In arena you control a character by     |");
            Console.WriteLine("|     pressing the keyboard.                  |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|     To access character info press 'c'.     |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|     To access inventory info press 'i'.     |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|     To save your progress_and export        |");
            Console.WriteLine("|     your character press 's'                |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|     All these options can be used           |");
            Console.WriteLine("|     anytime once your character is          |");
            Console.WriteLine("|     created.                                |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|     Type your character's name and          |");
            Console.WriteLine("|     press enter.                            |");
            Console.WriteLine("|                                             |");
            Console.WriteLine("|_____________________________________________|");

            player.name = Console.ReadLine();
        }

        public void ArenaPrompt()
        {
                Console.WriteLine(" _________________________________________");
                Console.WriteLine("|-----------------------------------------|");
                Console.WriteLine("|------------------Welcome To-------------|");
                Console.WriteLine("|------ ______________________________----|");
                Console.WriteLine("|------|         __  __               |---|");
                Console.WriteLine("|------|   /\\   |__||    |\\  |   /\\   |---|");
                Console.WriteLine("|------|  /--\\  |\\  |--  | \\ |  /--\\  |---|");
                Console.WriteLine("|------| /    \\ | \\ |__  |  \\| /    \\ |---|");
                Console.WriteLine("|------|______________________________|---|");
                Console.WriteLine("|--------A_retro_console_RPG_adventure----|");
                Console.WriteLine("|-----------------------------------------|");
                Console.WriteLine("|-----------------------------------------|");
                Console.WriteLine("|_________________________________________|");
        }
        public void SetRace()
        {
                    var read = Console.ReadLine();
                    if (read == "human" || read == "Human")
                    {
                        player.Race = "Human";
                        Console.WriteLine(" ________________________________________");
                        Console.WriteLine("|    A common human, with a mixture of   |");
                        Console.WriteLine("|    talents.                            |");
                        Console.WriteLine("|________________________________________|");
                    }
                    else if (read == "elf" || read == "Elf")
                    {
                        player.Race = "Elf";
                        Console.WriteLine(" ________________________________________");
                        Console.WriteLine("|     Agile and beautiful elf, yet       |");
                        Console.WriteLine("|     fragile and weak.                  |");
                        Console.WriteLine("|________________________________________|");
                    }
                    else if (read == "dwarf" || read == "Dwarf")
                    {
                        player.Race = "Dwarf";
                        Console.WriteLine(" ________________________________________");
                        Console.WriteLine("|     A cave dwelling dwarf, sturdy      |");
                        Console.WriteLine("|     and strong.                        |");
                        Console.WriteLine("|________________________________________|");
                    }
                    else
                    {
                        Console.WriteLine("There is no such class...yet");
                        SetRace();
                    }
        }
        public void SetClass()
        {
                    var read = Console.ReadLine();
                    if(read == "warrior" || read == "Warrior")
                    {
                        player.Job = "Warrior";
                        Console.WriteLine(" ______________________________________");
                        Console.WriteLine("|   You are a warrior of the northern  |");
                        Console.WriteLine("|   mountains, fierce with twohanded   |");
                        Console.WriteLine("|   weapons.                           |");
                        Console.WriteLine("|______________________________________|");
                    }
                    else if (read == "rogue" || read == "Rogue")
                    {
                        player.Job = "Rouge";
                        Console.WriteLine(" ______________________________________");
                        Console.WriteLine("|   You are a rogue of the city slums, |");
                        Console.WriteLine("|   onehanded weapons are you expertise|");
                        Console.WriteLine("|______________________________________|");
                    }
                    else if (read == "mage" || read == "Mage")
                    {
                        player.Job = "Mage";
                        Console.WriteLine(" ______________________________________");
                        Console.WriteLine("|   You are a mage from the mage       |");
                        Console.WriteLine("|   college, wielding mighty magic.    |");
                        Console.WriteLine("|______________________________________|");
                    }
                    else
                    {
                        Console.WriteLine("There is no such class...yet");
                        SetClass();
                    }
        }

        public void DisplayClasses()
        {
            Console.WriteLine(" _________________________________________");
            Console.WriteLine("|     What class is your character?       |");
            Console.WriteLine("|                                         |");
            Console.WriteLine("|     Warrior                             |");
            Console.WriteLine("|     Rogue                               |");
            Console.WriteLine("|     Mage                                |");
            Console.WriteLine("|                                         |");
            Console.WriteLine("|     Type the name of the class          |");
            Console.WriteLine("|_________________________________________|");
        }
        public void DisplayRaces()
        {
            Console.WriteLine(" _________________________________________");
            Console.WriteLine("|     What race is your character?        |");
            Console.WriteLine("|                                         |");
            Console.WriteLine("|     Human                               |");
            Console.WriteLine("|     Elf                                 |");
            Console.WriteLine("|     Dwarf                               |");
            Console.WriteLine("|                                         |");
            Console.WriteLine("|     Type the name of the race           |");
            Console.WriteLine("|_________________________________________|");
        }


        public void CalcInitMods(Player p)
        {
            switch (p.Race)
            {
                case ("Human"):
                    p.attributes.attributes["Charisma"] += 2;
                    p.currencies["Silver"] += 2;
                    p.skills.skills["Bargain"] += 1;
                    break;
                case ("Elf"):
                    p.attributes.attributes["Dexterity"] += 2;
                    p.attributes.attributes["Strength"] -= 2;
                    p.attributes.attributes["Toughness"] -= 1;
                    p.attributes.attributes["Intellect"] += 1;
                    p.attributes.attributes["Charisma"] += 1;
                    p.currencies["Silver"] += 1;
                    p.skills.skills["Alchemy"] += 1;

                    break;
                case ("Dwarf"):
                    p.attributes.attributes["Strength"] += 1;
                    p.attributes.attributes["Toughness"] += 2;
                    p.attributes.attributes["Charisma"] -= 1;
                    p.currencies["Silver"] += 1;
                    p.skills.skills["Smithing"] += 1;
                    break;
            }

            switch(p.Job)
            {
                case ("Warrior"):
                    p.attributes.attributes["Strength"] += 2;
                    p.skills.skills["Twohanded"] += 1;
                    break;
                case ("Rogue"):
                    p.attributes.attributes["Dexterity"] += 2;
                    p.skills.skills["Onehanded"] += 1;
                    break;
                case ("Mage"):
                    p.attributes.attributes["Intellect"] += 2;
                    p.skills.skills["Magic"] += 1;
                    break;
            }
            player.Instantiate();
        }
    }

    
}