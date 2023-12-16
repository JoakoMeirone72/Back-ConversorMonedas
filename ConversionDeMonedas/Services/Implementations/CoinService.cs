﻿using ConversionDeMonedas.Data;
using ConversionDeMonedas.Entities;
using ConversionDeMonedas.Models.Dtos;

namespace ConversionDeMonedas.Services.Implementations
{
    public class CoinService
    {
        private readonly ConversionDeMonedasContext _CDMContext;
        public CoinService(ConversionDeMonedasContext context)
        {
            _CDMContext = context;
        }

        public double Convert(Usuario usuario, double amount, ToConvert toConvert)
        {
            double result = amount * toConvert.ICfromConvert / toConvert.ICtoConvert;
            return result;
        }

        public void CreateCoin(int LoggeduserId, CreateAndUpdateCoinDto dto)
        {
            MonedasUser newCoin = new MonedasUser()
            {
                Leyenda = dto.Leyenda,
                Simbolo = dto.Simbolo,
                IC = dto.IC,
                UserId = LoggeduserId
               
            };
            _CDMContext.monedasUser.Add(newCoin);
            _CDMContext.SaveChanges();
        }

        public void UpdateCoin(int monedaId, string leyenda, CreateAndUpdateCoinDto dto)
        {
            MonedasUser? coinToUpdate = _CDMContext.monedasUser.SingleOrDefault(c => c.Id == monedaId);
            Favoritas? coinFavToUpdate = _CDMContext.Favoritas.SingleOrDefault(f => f.Leyenda == leyenda);

            if(coinToUpdate is not null) 
            {
                //edit user coin 
                coinToUpdate.Leyenda = dto.Leyenda;
                coinToUpdate.Simbolo = dto.Simbolo;
                coinToUpdate.IC = dto.IC;

                if(coinFavToUpdate is not null)
                {
                    //edit fav coin
                    coinFavToUpdate.Leyenda = dto.Leyenda;
                    coinFavToUpdate.Simbolo = dto.Simbolo;
                    coinFavToUpdate.IC = dto.IC;
                }
                _CDMContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("El Id no coincide");
            }
        }
        public void DeleteCoin(int monedaId, string leyenda)
        {
            Favoritas? coinFavToDelete = _CDMContext.Favoritas.SingleOrDefault(f => f.Leyenda == leyenda);
            if(coinFavToDelete is not null)
            {
                _CDMContext.Favoritas.Remove(coinFavToDelete);
            }
            _CDMContext.monedasUser.Remove(_CDMContext.monedasUser.Single(c => c.Id == monedaId));
            _CDMContext.SaveChanges();
        }

        public void AddFavCoin(int LoggeduserId, AddFavoriteDto dto)
        {
            List<Favoritas> coins = _CDMContext.Favoritas.Where(u => u.Id == LoggeduserId).ToList();
            
            bool esta = false;

            foreach (Favoritas coin in coins)
            {
                if(dto.Leyenda == coin.Leyenda)
                {
                    esta = true;
                    break;
                }
            }
            
            if(esta == false) 
            { 
                Favoritas newFav = new Favoritas()
                {
                    Leyenda = dto.Leyenda,
                    Simbolo = dto.Simbolo,
                    IC = dto.IC,
                    UserId = LoggeduserId
                };
                _CDMContext.Favoritas.Add(newFav);
                _CDMContext.SaveChanges();
            } else
            {
                Console.WriteLine("Esa moneda ya esta en favoritos");
            }
        }

        public void DeleteFavCoin(int monedaId) 
        {
            _CDMContext.Favoritas.Remove(_CDMContext.Favoritas.Single(c => c.Id == monedaId));
            _CDMContext.SaveChanges();
        }
    }
}
