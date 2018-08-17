using System;
using FluentBehaviourTree;

namespace Freescape.Game.Server.Creature
{
    public class TestCreature: CreatureBase
    {
        private readonly BehaviourTreeBuilder _builder;

        public TestCreature(BehaviourTreeBuilder builder)
        {
            _builder = builder;
        }

        public override bool IgnoreNWNEvents => false;
        
        public override IBehaviourTreeNode Behaviour
        {
            get
            {
                return _builder
                    .Sequence("seq1")
                    .Do("action1", t =>
                    {
                        var ticks = Self.GetLocalInt("current_tick") + 1;
                        Self.SetLocalInt("current_tick", ticks);

                        if (ticks % 5 == 0)
                        {
                            Console.WriteLine("action2 firing tick = " + ticks);
                            return BehaviourTreeStatus.Success;
                        }

                        return BehaviourTreeStatus.Failure;
                    })
                    .End()
                    .Build();
            }
        }
    }
}
