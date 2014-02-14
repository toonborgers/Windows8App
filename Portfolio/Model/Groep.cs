using System;
using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Portfolio.Model
{
    public class Groep
    {
        private static readonly Groep Sloebers = new Groep
        {
            Naam = "Sloebers",
            Kleur = new SolidColorBrush(Color.FromArgb(180, 128, 0, 128)),
            ImageLocation = "ms-appx:///Assets/Groepen/sloebers.png"
        };

        private static readonly Groep Speelclub = new Groep
        {
            Naam = "Speelclub",
            Kleur = new SolidColorBrush(Color.FromArgb(180, 255, 255, 0)),
            ImageLocation = "ms-appx:///Assets/Groepen/speelclub.png"
        };

        private static readonly Groep Rakkers = new Groep
        {
            Naam = "Rakkers",
            Kleur = new SolidColorBrush(Color.FromArgb(180, 0, 128, 0)),
            ImageLocation = "ms-appx:///Assets/Groepen/rakkers.png"
        };

        private static readonly Groep Toppers = new Groep
        {
            Naam = "Toppers",
            Kleur = new SolidColorBrush(Color.FromArgb(180, 255, 0, 0)),
            ImageLocation = "ms-appx:///Assets/Groepen/toppers.png"
        };

        private static readonly Groep Kerels = new Groep
        {
            Naam = "Kerels",
            Kleur = new SolidColorBrush(Color.FromArgb(180, 0, 0, 255)),
            ImageLocation = "ms-appx:///Assets/Groepen/kerels.png"
        };

        private static readonly Groep Aspiranten = new Groep
        {
            Naam = "Aspiranten",
            Kleur = new SolidColorBrush(Color.FromArgb(180, 255, 165, 0)),
            ImageLocation = "ms-appx:///Assets/Groepen/aspiranten.png"
        };

        public static readonly IList<Groep> ALLE = new List<Groep>
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