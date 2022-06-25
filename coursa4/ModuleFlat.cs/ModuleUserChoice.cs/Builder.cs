using System;
using System.Collections.Generic;

namespace coursa4
{
    public class ChooseInterior
    {
        public string ChooseInteriorDesign()
        {
            ShowInteriorDesign();

            Console.WriteLine("Are you ready to choose one of them?\nEnter interion name make the choice\nOr enter 'no' to come back to your flat page");
            string choice = Console.ReadLine().ToLower();
            if (choice == "traditional" || choice == "contemporary" || choice == "industrial" || choice == "modern")
            {
                return choice;
            }
            else if (choice == "no")
            {
                return null;
            }
            Console.WriteLine("\nIncorrect value\nYou can enter only 'traditional'/'contemporary'/'industrial'/'modern' or 'no'\n");
            return null;
        }

        private void ShowInteriorDesign()
        {
            Console.WriteLine("Here you can see a list of interior designs for your flat:\n\n");

            DesignBuilder designBuilder;
            Interior interior = new Interior();

            designBuilder = new Design1Builder();
            interior.OfferDesign(designBuilder);
            Console.WriteLine(designBuilder.Design.GetDesignInfo());

            designBuilder = new Design2Builder();
            interior.OfferDesign(designBuilder);
            Console.WriteLine(designBuilder.Design.GetDesignInfo());

            designBuilder = new Design3Builder();
            interior.OfferDesign(designBuilder);
            Console.WriteLine(designBuilder.Design.GetDesignInfo());

            designBuilder = new Design4Builder();
            interior.OfferDesign(designBuilder);
            Console.WriteLine(designBuilder.Design.GetDesignInfo());
        }
    }

    class Interior
    {
        public void OfferDesign(DesignBuilder designsBuilder)
        {
            designsBuilder.BuildMainMaterials();
            designsBuilder.BuildColorPalette();
            designsBuilder.BuildDistinguishingFeatures();
        }
    }

    abstract class DesignBuilder
    {
        protected Design design;

        public Design Design { get { return design; } }

        public abstract void BuildMainMaterials();
        public abstract void BuildColorPalette();
        public abstract void BuildDistinguishingFeatures();
    }

    class Design1Builder : DesignBuilder
    {
        public Design1Builder()
        {
            design = new Design("Traditional");
        }

        public override void BuildMainMaterials()
        {
            design["materials"] = "Wood";
        }

        public override void BuildColorPalette()
        {
            design["color"] = "Neutral walls, warm, dark, gold & silver furnishings";
        }

        public override void BuildDistinguishingFeatures()
        {
            design["features"] = "Symmethrical, collumns, crown moulding, detailed woodwork";
        }
    }

    class Design2Builder : DesignBuilder
    {
        public Design2Builder()
        {
            design = new Design("Contemporary");
        }

        public override void BuildMainMaterials()
        {
            design["materials"] = "Light woods, glass, stainless steeld";
        }

        public override void BuildColorPalette()
        {
            design["color"] = "Brown, taupe, cream, white, black";
        }

        public override void BuildDistinguishingFeatures()
        {
            design["features"] = "Open space, uncluttered, airy, strong emphasis on line and form";
        }
    }

    class Design3Builder : DesignBuilder
    {
        public Design3Builder()
        {
            design = new Design("Industrial");
        }

        public override void BuildMainMaterials()
        {
            design["materials"] = "Weathered wood, metal, brick, concrete";
        }

        public override void BuildColorPalette()
        {
            design["color"] = "Neutral shades – brown, tan, black, cream, grey";
        }

        public override void BuildDistinguishingFeatures()
        {
            design["features"] = "Open concept layout, high ceilings, exposed materials, \nuncluttered, functional, mix of old and new, negative space";
        }
    }

    class Design4Builder : DesignBuilder
    {
        public Design4Builder()
        {
            design = new Design("Modern");
        }

        public override void BuildMainMaterials()
        {
            design["materials"] = "Wood, metal, glass, steel";
        }

        public override void BuildColorPalette()
        {
            design["color"] = "Monochromatic, neutral, earthy";
        }

        public override void BuildDistinguishingFeatures()
        {
            design["features"] = "Clean lines, simple furnishings, lack of clutter & adornments, \n'form follows function'";
        }
    }

    class Design
    {
        private string _designType;
        private Dictionary<string, string> _designIdeas = new Dictionary<string, string>();

        public Design(string designType)
        {
            this._designType = designType;
        }

        public string this[string key]
        {
            get { return _designIdeas[key]; }
            set { _designIdeas[key] = value; }
        }

        public string GetDesignInfo()
        {
            return $"Design Type: {_designType}\n" + 
            $"Main materials: {_designIdeas["materials"]}\n" + 
            $"Color palette: {_designIdeas["color"]}\n" + 
            $"Distinguishing features: {_designIdeas["features"]}\n";
        }
    }
}