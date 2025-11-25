<%@ Application Codebehind="Global.asax.cs" Inherits="CSE445PublicLibrary.Global" Language="C#" %>

<script runat="server">
    void Application_AuthenticateRequest(object sender, EventArgs e)
    {
        if (Context.User != null && Context.User.Identity.IsAuthenticated && 
            Context.User.Identity is FormsIdentity)
        {
            FormsIdentity identity = (FormsIdentity)Context.User.Identity;
            FormsAuthenticationTicket ticket = identity.Ticket;
            
            // Get the role from UserData
            string role = ticket.UserData;
            
            if (!string.IsNullOrEmpty(role))
            {
                // Create a new Principal with roles
                string[] roles = { role };
                Context.User = new System.Security.Principal.GenericPrincipal(identity, roles);
            }
        }
    }
</script>
