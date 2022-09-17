using StackExchange.Redis;

namespace DummyAnnouncer
{
    public static class SetupDependencies
    {
        public static void AddRedis(this IServiceCollection services, string connectionString)
        {
            var redis = ConnectionMultiplexer.Connect(connectionString);

            if (!redis.IsConnected)
            {
                throw new Exception();
            }

            var database = redis.GetDatabase();

            var instanceOne = "I1";
            var instanceTwo = "I2";

            database.StringSet(
                !database.KeyExists(instanceOne) 
                    ? instanceOne 
                    : instanceTwo,
                Guid.NewGuid().ToString());

            services.AddSingleton<IConnectionMultiplexer>(provider => redis);

        }
    }
}
