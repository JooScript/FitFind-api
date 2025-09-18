namespace ECommerce.Bl.Enums.Status;

public class Status
{
    public enum enCurrentState : int
    {
        Deleted = 0,
        Active = 1,
        InActive = 2
    }

    /// <summary>
    /// Represents the various states a support ticket can be in during its lifecycle.
    /// Used for tracking progress, reporting, and automating workflow actions.
    /// </summary>
    public enum enSupportTicketState : int
    {
        Deleted = 0,

        /// <summary>
        /// The ticket has been created but has not yet been reviewed or triaged by an agent.
        /// This is the initial state of a newly submitted ticket.
        /// </summary>
        Received = 1,

        /// <summary>
        /// The ticket has been reviewed, categorized, and assigned a priority. It is awaiting assignment to an agent or team.
        /// </summary>
        Triaged = 2,

        /// <summary>
        /// The ticket has been assigned to a specific agent or team and is awaiting initial action.
        /// </summary>
        Assigned = 3,

        /// <summary>
        /// An agent is actively working on the ticket, investigating the root cause.
        /// </summary>
        Investigating = 4,

        /// <summary>
        /// The root cause is identified and a solution is being implemented by the agent.
        /// </summary>
        FixInProgress = 5,

        /// <summary>
        /// A resolution has been developed but is pending the next scheduled deployment or release to be applied to the live environment.
        /// </summary>
        PendingRelease = 6,

        /// <summary>
        /// Awaiting a response, additional information, or confirmation from the customer.
        /// The SLA timer is typically paused in this state.
        /// </summary>
        WaitingForCustomer = 7,

        /// <summary>
        /// Awaiting input or action from another internal team (e.g., Engineering, DevOps, Billing).
        /// The ticket is blocked on internal resources.
        /// </summary>
        WaitingForInternalTeam = 8,

        /// <summary>
        /// The ticket is blocked by an external third party (e.g., vendor, service provider).
        /// No immediate action is expected from the support team.
        /// </summary>
        OnHold = 9,

        /// <summary>
        /// The agent has provided a solution or implemented a fix. The ticket is awaiting verification from the customer.
        /// This is a transitional state before being Closed.
        /// </summary>
        Solved = 10,

        /// <summary>
        /// The customer has verified that the solution is successful and the issue is fully resolved.
        /// This is a terminal state.
        /// </summary>
        ClosedVerified = 11,

        /// <summary>
        /// The ticket was closed automatically due to no response from the customer after a resolved status.
        /// This is a terminal state.
        /// </summary>
        ClosedNoResponse = 12,

        /// <summary>
        /// The ticket was invalid, withdrawn by the user, or identified as spam.
        /// This is a terminal state.
        /// </summary>
        Cancelled = 13,

        /// <summary>
        /// The ticket is a duplicate of an existing active ticket. It will be closed and linked to the master ticket.
        /// This is a terminal state.
        /// </summary>
        Duplicate = 14,

        /// <summary>
        /// The customer has reported that the issue persists after being marked Solved. The ticket re-enters the workflow.
        /// </summary>
        Reopened = 15
    }




}