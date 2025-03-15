using StackExchange.Redis;

namespace _MultiShop.Basket.Settings
{
    public class RedisService
    {
        private string _host { get; set; }
        private int _port { get; set; }

        private ConnectionMultiplexer _connectionMultiplexer; //Redise bağ:{polanmak için köprü görevi görür.
        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");
        public IDatabase GetDb(int db = 1) => _connectionMultiplexer.GetDatabase(0);
    }
}
