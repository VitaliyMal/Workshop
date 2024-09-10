using Workshop.Server.DTOs.State_TypeDTOs;
using Workshop.Server.Entity;

namespace Workshop.Server.Mapper
{
    public static class State_TypeMapper
    {
        public static State_Type ToEntity(this AddState_TypeDTO addState_Type)
        {
            return new State_Type()
            {
                State_Type_Title=addState_Type.State_Type_Title
            };
        }

        public static State_Type ToEntity(this UpgradeState_TypeDTO UpState_Type, int id)
        {
            return new State_Type()
            {
                State_Type_Title=UpState_Type.State_Type_Title
            };
        }

        public static State_TypeDTO ToState_TypeDTO(this State_Type state_Type)
        {
            return new State_TypeDTO(
                state_Type.Id,
                state_Type.State_Type_Title
            );
        }
    }
}
