namespace main
{
    public struct Blow : IBlow
    {
        public Ball ball { get; private set; }
        public float forceValue { get; private set; }

        public Blow(Ball ball, float forceValue)
        {
            this.ball = ball ?? throw new System.ArgumentNullException();
            this.forceValue = forceValue;
        }

        public void MakeBlow(UnityEngine.Vector3 direction)
        {
            if (ball == null) throw new System.NullReferenceException();

            ball.AddForce(direction, forceValue);
        }
    }
}
