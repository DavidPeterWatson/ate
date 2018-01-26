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