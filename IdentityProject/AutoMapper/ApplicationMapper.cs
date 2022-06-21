using AutoMapper;

namespace IdentityProject.AutoMapper
{
    public static class ApplicationMapper <TSource, TDestination>
    {
        private static Mapper _mapper = new Mapper(new MapperConfiguration(cfg =>
             cfg.CreateMap<TDestination, TSource>().ReverseMap()
      ));
        public static TDestination Map(TSource source)
        {
            return _mapper.Map<TDestination>(source);
        }

        public static TDestination Maps(TSource source, TDestination destination)
        {
            return _mapper.Map<TSource, TDestination>(source, destination);
        }
        public static List<TDestination> MapList(List<TSource> source)
        {
            var list = new List<TDestination>();

            source.ForEach(item => list.Add(Map(item)));

            return list;
        }

    }

}
