namespace BpmsApi.Enums
{
    public enum NodeTypeEnum
    {
        //Tasks
        FormTask = 0,
        ManualTask,
        ScriptTask,
        SubTask,

        //Events
        StartEvent,
        StartByCatchSignalEvent,
        StartByTimerEvent,
        StartByMessageReciverEvent,
        StartByCatchingEmailEvent,
        StartByCatchingSmsEvent,
        StartByConditionEvent,
        IntermediateThrowSignalEvent,
        IntermediateCatchSignalEvent,
        IntermediateTimerEvent,
        IntermediateMessageSenderEvent,
        IntermediateMessageReceiverEvent,
        IntermediateThrowEmailEvent,
        IntermediateCatchingEmailEvent,
        IntermediateThrowSmsEvent,
        IntermediateCatchingSmsEvent,
        IntermediateHttpRequestEvent,
        IntermediateConditionEvent,
        EndEvent,
        EndSignalThrowEvent,
        EndMessageSenderEvent,
        EndThrowEmailEvent,
        EndThrowSmsEvent,
        EndHttpRequestEvent,
        EndErrorEvent,
        EndTerminateEvent,

        //Gateways
        ExclusiveDivergingGateway,
        ExclusiveConvergingGateway,
        ParallelDivergingGateway,
        ParallelConvergingGateway,
        InclusiveDivergingGateway,
        InclusiveConvergingGateway,
        EventBasedGateway,

        //Other
        DataObjectReference,
        DataStoreReference,
        Pool,
        Group
    }
}
