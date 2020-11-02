﻿using projet_CDAA_2020_2021.core.datastructures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace projet_CDAA_2020_2021.core.jeux
{
    public class EnsembleJeux : Ensemble<Jeu>
    {
        public EnsembleJeux() : base()
        {}

        public EnsembleJeux(List<Jeu> liste) : base (liste)
        { }

        public override void Init()
        {
            Add(new Jeu("Metal Gear Solid 2: Subsistance", "Un jeu de Hideo Kojima", "PC, PS2", "Konami, avec Hideo Kojima", Genre.Infiltration, 9.99, new DateTime(2003, 07, 14), false));
            Add(new Jeu("Metal Gear Solid", "Un jeu de Hideo Kojima", "PC, PS1, GameCube", "Konami, avec Hideo Kojima", Genre.Infiltration, 9.99, new DateTime(2000, 04, 21), false));
            Add(new Jeu("Metal Gear Solid V: The Phantom Pain", "Un jeu de Hideo Kojima", "PC, PS4, PS3", "Konami avec Hideo Kojima", Genre.Infiltration, 50.00, new DateTime(2013, 08, 22), false));
            Add(new Jeu("Dragon Ball: Fighter Z", "JAPOOON", "PC, PS4, XBOX ONE", "Akira Toriyama", Genre.Combat, 40.00, new DateTime(2017, 05, 13), false));
            Add(new Jeu("Minecraft RTX Edition", "Enfin des graphismes sympas", "PC", "Microsoft, Mojang", Genre.Aventure, 25.00, new DateTime(2018, 10, 12), false));
            Add(new Jeu("Genshin Impact", "Copier Coller de Zelda BotW", "PC, PS4, iOS, Android", "MiHoYo", Genre.Action_RPG, 0.00, new DateTime(2020, 09, 25), false));
            Add(new JeuRetro("Mario Bros 3", "Un clasiqque des jeux de plateforme", "Super NES", "Nintendo", Genre.Plateforme, 40.00, new DateTime(1991, 11, 30), false, "presque neuf", true));
        }

        //TODO: vérifier les cast dans les appels a search, surtout les DateTime.
        public override List<Jeu> Search(Field field, object arg)
        {
            List<Jeu> tmp = new List<Jeu>();

            foreach (Jeu j in liste)
            {
                //TODO: passer tous les Field == Field en Field.Equals(Field) OU IMPLEMNETER OPERATOR==

                if (field == FieldJeu.Nom && j.Nom == (string)arg)
                    tmp.Add(j);

                else if (field.Equals(FieldJeu.Genre) && j.Genre.Equals((Genre)arg))
                    tmp.Add(j);

                else if (field == FieldJeu.Description && j.Description == (string)arg)
                    tmp.Add(j);

                else if (field == FieldJeu.Plateforme && j.Plateforme == (string)arg)
                    tmp.Add(j);

                else if (field == FieldJeu.Editeur && j.Editeur == (string)arg)
                    tmp.Add(j);

                else if (field == FieldJeu.Prix && j.Prix == (double)arg)
                    tmp.Add(j);

                else if (field == FieldJeu.Sortie && j.Sortie == (DateTime)arg)
                    tmp.Add(j);

                else if (field == FieldJeu.Reconditionne && j.Reconditionne == (bool)arg)
                    tmp.Add(j);

                else if (field == FieldJeu.Photo && j.Photo == (Image)arg)
                    tmp.Add(j);

                else if (field == FieldJeu.Retro && j.GetType().Equals(typeof(JeuRetro)))
                    tmp.Add(j);

                //pas sure que ça fonctionne
                else if (field == FieldJeu.Etat && (j as JeuRetro).Etat == (string)arg)
                    tmp.Add(j);

                else if (field == FieldJeu.Notice && (j as JeuRetro).Notice == (bool)arg)
                    tmp.Add(j);
            }
            return tmp;
        }

        //TODO: remonter la méthode à Ensemble et passer la signature en override
        public Jeu SearchSingle(string property, object arg)
        {
            foreach(Jeu j in liste)
            {
                switch(property)
                {
                    case "nom":
                        if (j.Nom == (string)arg)
                            return j;
                        break;
                    case "genre":
                        if (j.Genre == (Genre)arg)
                            return j;
                        break;
                    case "plateforme":
                        if (j.Plateforme == (string)arg)
                            return j;
                        break;
                    case "editeur":
                        if (j.Editeur == (string)arg)
                            return j;
                        break;

                    case "prix":
                        if (j.Prix == (double)arg)
                            return j;
                        break;

                    case "sortie":
                        if (j.Sortie == (DateTime)arg)
                            return j;
                        break;

                    case "reconditionne":
                        if (j.Reconditionne == (bool)arg)
                            return j;
                        break;

                    case "retro":
                        if (j.GetType().Equals(typeof(JeuRetro)))
                            return j;
                        break;
                }
            }

            return null;
        }

        public override List<string[]> ToStringArray()
        {
            List<string[]> output = new List<string[]>();
            foreach(Jeu j in liste)
            {

                output.Add(j.ToStringArray().ToArray());
            }

            return output;
        }

        public List<string> GetAllNames()
        {
            List<string> output = new List<string>();

            foreach(Jeu j in liste)
            {
                output.Add(j.Nom);
            }

            return output;
        }
    }
}
