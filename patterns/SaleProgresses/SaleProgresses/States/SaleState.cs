using SaleProgresses.Domain;

namespace SaleProgresses.States
{
    public class SaleState
    {
        private BaseState _currentState;

        public SaleState()
        {
            _currentState = new Initial();
        }

        public SaleState(BaseState state)
        {
            _currentState = state;
        }

        public bool Handle(SaleProgress progress)
        {


            return true;
        }

        //public bool ToProcessing()
        //{
        //    _currentState = new Proccessing();
        //    return true;
        //}

        //public bool ToWaitCall()
        //{
        //    _currentState = new WaitCall();
        //    return true;
        //}

        //public bool ToFailure()
        //{
        //    _currentState = new Failure();
        //    return true;
        //}



    }
}