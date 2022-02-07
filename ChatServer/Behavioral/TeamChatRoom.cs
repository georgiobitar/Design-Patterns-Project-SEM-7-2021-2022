namespace ChatServer.Behavioral
{
    public class TeamChatRoom : ChatRoom
    {
        private List<TeamMember> members = new List<TeamMember>();

        public override void Register(TeamMember member)
        {
            member.SetChatroom(this);
            this.members.Add(member);
        }

        public override void Send(string from, string message)
        {
            this.members.ForEach(m => m.Receive(from, message));
        }

        public void RegisterMembers(params TeamMember[] teamMembers)
        {
            foreach (var teamMember in teamMembers)
            {
                this.Register(teamMember);
            }
        }
    }
}
