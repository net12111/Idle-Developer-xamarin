﻿using Idle.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Idle.Helpers
{
    //Non-instantiable Helper class that handles file IO for data persistence
    public static class FileHelper
    {

        //File Path to json file containing Player data
        private static readonly string file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Player.json");

        private static readonly string fieldfile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Fields.json");


        //Serializes Player object and writes the content to Player.json
        public static void WritePlayer(Player player)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(player);
            File.WriteAllText(file, json);
        }


        //Reads Player.json and returns a deserialized Player object from the file data
        public static Player ReadPlayer()
        {
            //string json = File.ReadAllText(file);
            //var player = Newtonsoft.Json.JsonConvert.DeserializeObject<Player>(json);

            var player = new Player();

            return player;
        }

        public static void ClearPlayer()
        {
            File.WriteAllText(file, string.Empty);
        }



        public static void WriteFields(Dictionary<string, Field> fields)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(fields);
            File.WriteAllText(fieldfile, json);
        }

        public static Dictionary<string, Field> ReadFields()
        {
            string json = File.ReadAllText(fieldfile);
            var fields = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, Field>>(json);

            return fields;
        }

    }
}
