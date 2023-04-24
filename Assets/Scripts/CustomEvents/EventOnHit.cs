using Unity.VisualScripting;

namespace StateMachine {

    [UnitTitle("Event On Hit")]//The Custom Scripting Event node to receive the Event. Add "On" to the node title as an Event naming convention.
    [UnitCategory("Events\\MyCustomEvent")]//Set the path to find the node in the fuzzy finder as Events > My Events.
    public class EventOnHit : EventUnit<float> {

        [DoNotSerialize]// No need to serialize ports.
        public ValueOutput healthLeft { get; private set; }// The Event output data to return when the Event is triggered.
        protected override bool register => true;

        // Add an EventHook with the name of the Event to the list of Visual Scripting Events.
        public override EventHook GetHook(GraphReference reference) {
            return new EventHook(CustomEventNames.CustomEvent);
        }
        protected override void Definition() {
            base.Definition();
            // Setting the value on our port.
            healthLeft = ValueOutput<float>(nameof(healthLeft));
        }
        // Setting the value on our port.
        protected override void AssignArguments(Flow flow, float health) {
            flow.SetValue(healthLeft, health);
        }
    }
}