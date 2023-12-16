using ConversionDeMonedas.Data;
using ConversionDeMonedas.Entities;
using ConversionDeMonedas.Helpers;
using ConversionDeMonedas.Models.Dtos;
using ConversionDeMonedas.Models.Enum;

namespace ConversionDeMonedas.Services.Implementations
{
    public class ViewService
    {
        private readonly ConversionDeMonedasContext _CDMContext;
        public ViewService(ConversionDeMonedasContext context)
        {
            _CDMContext = context;
        }

        public void UpdateSub(int userId, Suscripcion sub)
        {
            Usuario userToUpdate = _CDMContext.usuario.First(U => U.Id == userId);
            Totalconversiones total = new();

            userToUpdate.Suscripcion = sub;
            userToUpdate.TotalConversiones = total.GetTotalconversiones(sub);
            _CDMContext.SaveChanges();
        }

        public string GetSub(int userId)
        {
            Usuario user = _CDMContext.usuario.First(u => u.Id == userId);

            string sub = user.Suscripcion.ToString();

            return sub;
        }

        public int GetTotalConvert(int userId)
        {
            Usuario user = _CDMContext.usuario.First(u => u.Id == userId);

            int total = user.TotalConversiones;

            return total;
        }

        public List<MonedasUser> GetUsersCoins(int LoggeduserId)
        {
            List<MonedasUser> coins = _CDMContext.monedasUser.Where(u => u.UserId == LoggeduserId).ToList();
            return coins;
        }
        public MonedaDto GetUserCoinById(int id)
        {
            MonedasUser monedaGet = _CDMContext.monedasUser.Single(u => u.Id == id);
            MonedaDto moneda = new MonedaDto()
            {
                Id = monedaGet.Id,
                Leyenda = monedaGet.Leyenda,
                Simbolo = monedaGet.Simbolo,
                IC = monedaGet.IC
            };
            return moneda;
        }

        public List<MonedasDefault> GetDefaultCoins()
        {
            List<MonedasDefault> coins = _CDMContext.monedasDefault.ToList();
            return coins;
        }


        public List<Favoritas> GetFavsCoins(int LoggeduserId)
        {
            List<Favoritas> coins = _CDMContext.Favoritas.Where(u => u.UserId == LoggeduserId).ToList();
            return coins;
        }
        public Favoritas GetFavCoinByLeyenda(int userid,string leyenda)
        {
            Favoritas? monedaGet = _CDMContext.Favoritas.SingleOrDefault(f => f.Leyenda == leyenda && f.UserId == userid);
            return monedaGet;
        }
    }
}
