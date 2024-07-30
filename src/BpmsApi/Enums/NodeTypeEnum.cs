namespace BpmsApi.Enums
{
    public enum NodeTypeEnum
    {
        //Tasks
        FormTask = 0,
        ManualTask,
        ScriptTask,
        SubProcessTask,

        //Events
        StartProcessEvent,
        StartProcessByCatchSignalEvent,
        StartProcessByTimerEvent,
        StartProccessByMessageReciverEvent,
        StartProcessByCatchingEmailEvent,
        StartProcessByCatchingSmsEvent,
        StartProcessByConditionEvent,
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
        EndProccessEvent,
        EndProccessSignalThrowEvent,
        EndMessageSenderEvent,
        EndProccessThrowEmailEvent,
        EndProccessThrowSmsEvent,
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
