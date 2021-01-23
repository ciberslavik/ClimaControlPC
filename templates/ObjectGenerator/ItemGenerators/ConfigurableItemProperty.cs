namespace ObjectGenerator.ItemGenerators
{
    public class ConfigurableItemProperty
    {
        private string _propertyName;
        private string _propertyType;

        public string PropertyName
        {
            get => _propertyName;
            set => _propertyName = value;
        }

        public string PropertyType
        {
            get => _propertyType;
            set => _propertyType = value;
        }
    }
}