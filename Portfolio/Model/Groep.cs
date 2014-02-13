using System;
using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Portfolio.Model
{
    public class Groep
    {
        public static Groep Sloebers = new Groep
        {
            Naam = "Sloebers",
            Kleur = new SolidColorBrush(Color.FromArgb(150, 128, 0, 128)),
            ImageLocation = "ms-appx:///Assets/Groepen/sloebers.png"
        };

        public static Groep Speelclub = new Groep
        {
            Naam = "Speelclub",
            Kleur = new SolidColorBrush(Color.FromArgb(150, 255, 255, 0)),
            ImageLocation = "ms-appx:///Assets/Groepen/speelclub.png"
        };

        public static Groep Rakkers = new Groep
        {
            Naam = "Rakkers",
            Kleur = new SolidColorBrush(Color.FromArgb(150, 0, 128, 0)),
            ImageLocation = "ms-appx:///Assets/Groepen/rakkers.png"
        };

        public static Groep Toppers = new Groep
        {
            Naam = "Toppers",
            Kleur = new SolidColorBrush(Color.FromArgb(150, 255, 0, 0)),
            ImageLocation = "ms-appx:///Assets/Groepen/toppers.png"
        };

        public static Groep Kerels = new Groep
        {
            Naam = "Kerels",
            Kleur = new SolidColorBrush(Color.FromArgb(150, 0, 0, 255)),
            ImageLocation = "ms-appx:///Assets/Groepen/kerels.png"
        };

        public static Groep Aspiranten = new Groep
        {
            Naam = "Aspiranten",
            Kleur = new SolidColorBrush(Color.FromArgb(150, 255, 165, 0)),
            ImageLocation = "ms-appx:///Assets/Groepen/aspiranten.png"
        };

        public static IList<Groep> ALLE = new List<Groep>
        {
            Sloebers,
            Speelclub,
            Rakkers,
            Toppers,
            Kerels,
            Aspiranten
        };

        public String Naam { get; private set; }

        public SolidColorBrush Kleur { get; private set; }

        public String ImageLocation { get; private set; }
    }
}