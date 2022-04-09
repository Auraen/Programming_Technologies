using ProjetTask_1.DataLayer;

namespace ProjetTask_1.LogicLayer
{
    public class BusinessLogicAPI
    {
        public AbstractDataAPI dataAPI;
        public DataService service { get; set; }

        public BusinessLogicAPI(AbstractDataAPI dataAPI)
        {
            this.dataAPI = dataAPI;
            service = new DataService(this);
        }
    }

}
