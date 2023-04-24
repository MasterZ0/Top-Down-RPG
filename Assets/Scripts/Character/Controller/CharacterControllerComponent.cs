using TD.Data;

namespace TD.Character
{
    public abstract class CharacterControllerComponent
    { 
        protected CharacterPawn Controller { get; private set; }
        protected CharacterData Data => Controller.Data;

        public virtual void Init(CharacterPawn controller)
        {
            Controller = controller;
        }
    }

}