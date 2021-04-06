using DiscordRPC;

namespace HydraAIO.Discord
{
    class DiscordRPC1
    {

        public static DiscordRpcClient client;

        public static void Initialize()
        {
            client = new DiscordRpcClient("828935417130123294");
            client.Initialize();
            client.SetPresence(new RichPresence
            {
                // State = "HydraAIO",
                Details = "SensivityAIO v1",
                Buttons = new Button[]
                {
                    new Button() { Label = "Join The Discord!", Url = "https://discord.gg/zuB9qgw8yU"},
                    new Button() { Label = "Purchase Sensivity!", Url = "https://discord.gg/YxEh54D5BH"}
                },

                Timestamps = Timestamps.Now,
                Assets = new Assets
                {
                    LargeImageText = "discord.gg/zuB9qgw8yU",
                }
            });
        }
    }
}
