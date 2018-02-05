using ate.Extensions;

namespace ate.Projects
{
    public class Command : ate.Definitions.Command
    {
        public Feature Feature;
        public Entity Entity;

        public App App
        {
            get
            {
                return Entity?.App;
            }
        }

        public string LowerCaseName
        {
            get
            {
                return Name.ToLower();
            }
        }
        public string name
        {
            get
            {
                return LowerCaseName;
            }
        }

        public string NAME
        {
            get
            {
                return Name.ToUpper();
            }
        }

        public string naMe
        {
            get
            {
                return Name.ToCamelCase();
            }
        }
        
        public string na_me
        {
            get
            {
                return Name.ToUnderscoreCase();
            }
        }

        public string hyphenname
        {
            get
            {
                return Name.ToHyphenCase();
            }
        }
        public bool IsLicensed
        {
            get
            {
                return Feature != null;
            }
        }

        public void Build()
        {

        }

        public void PostBuild()
        {

            if (Feature.Guid != null)
            {
                Feature = App.FindFeature(FeatureName);
            }

        }
    }
}