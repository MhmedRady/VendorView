namespace VendorView.WebApi
{
    public static class DtoTypeMapper
    {
        private static readonly Dictionary<Type, Type> EntityToReadDtoMap = new Dictionary<Type, Type>();
        private static readonly Dictionary<Type, Type> EntityToWriteDtoMap = new Dictionary<Type, Type>();

        public static void RegisterDtoTypes(Type entityType, Type readDtoType, Type writeDtoType)
        {
            EntityToReadDtoMap[entityType] = readDtoType;
            EntityToWriteDtoMap[entityType] = writeDtoType;
        }

        public static Type GetReadDtoType(Type entityType)
        {
            return EntityToReadDtoMap.TryGetValue(entityType, out var readDtoType) ? readDtoType : null;
        }

        public static Type GetWriteDtoType(Type entityType)
        {
            return EntityToWriteDtoMap.TryGetValue(entityType, out var writeDtoType) ? writeDtoType : null;
        }
    }

}
