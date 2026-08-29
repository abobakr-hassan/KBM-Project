using Mapster;

namespace KBM_Backend.Application.Mappings;

public static class MapsterConfig
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig.GlobalSettings.Scan(
            typeof(MapsterConfig).Assembly);
    }
}