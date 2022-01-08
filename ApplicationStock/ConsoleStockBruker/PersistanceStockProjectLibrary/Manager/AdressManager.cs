using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using PersistanceStockProjectLibrary.Interfaces;
using ProjectStockDTOS;
using ProjectStockLibrary;

namespace PersistanceStockProjectLibrary.Manager
{
    internal class AdressManager :IAdressManager
    {
        private readonly Fixture _fixture = new Fixture();
        private List<AddressDto> adresses { get; set; } = new List<AddressDto>();
        /// <summary>
        /// Gets the creatures from the codex
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AddressDto> GetAddress()
        {
            var creatures = new List<Address>() { new Address("41 rue du pommier","","42000","saint-etienne","france") };
            
            foreach (var creature in creatures)
            {

                yield return new AddressDto() { _id = creature._id, _address_line_1 = creature._address_line_1, _address_line_2 = creature._address_line_2,_city = creature._city,_codePostal=creature._codePostal,_country=creature._country };
            }
        }
        public IEnumerable<Address> GetAllAddress()
        {
            var creatures = new List<Address>() { new Address("41 rue du pommier", "", "42000", "saint-etienne", "france") };
            return creatures;

        }

        public AddressDto GetById(int id)
        {
            return adresses[id];
        }


        public void Update(int id, AddressDto addressDto)
        {

            try
            {
                adresses[id] = addressDto;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erreur update " + ex.ToString());
            }

        }


        public void Add(AddressDto addressDto)
        {

            try
            {
                adresses.Add(addressDto);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erreur Add" + ex.ToString());
            }

        }


        public void Delete(AddressDto addressDto)
        {
            try
            {
                adresses.Remove(addressDto);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Erreur delete" + ex.ToString());
            }
        }
    }
}
