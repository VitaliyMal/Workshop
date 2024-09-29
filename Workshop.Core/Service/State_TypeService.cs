using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Core.Data.Remote;
using Workshop.Server.DTOs.Ingredient_TypeDTOs;
using Workshop.Server.DTOs.State_TypeDTOs;

namespace Workshop.Core.Service
{
    public class State_TypeService
    {
        private State_TypeRemoteDataSource _dataSource;

        public State_TypeService(State_TypeRemoteDataSource dataSource)
        {
            _dataSource = dataSource;
        }


        public async Task<List<State_TypeDTO>> GetAll()
        {
            return await _dataSource.GetState_Types();
        }

        public async Task<State_TypeDTO?> Get(int id)
        {
            foreach (State_TypeDTO state_Type in await _dataSource.GetState_Types())
            {
                if (state_Type.Id == id)
                {
                    return state_Type;
                }
            }
            return null;
        }

        public async Task Create(State_TypeDTO state_Type)
        {
            try
            {
                await _dataSource.PostState_Type(new AddState_TypeDTO(
                    state_Type.State_Type_Title
                    ));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await _dataSource.DeleteState_Type(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(UpgradeState_TypeDTO state_Type)
        {
            try
            {
                await _dataSource.UpdateState_Type(new UpgradeState_TypeDTO(
                    state_Type.id,
                    state_Type.State_Type_Title
                    ));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

