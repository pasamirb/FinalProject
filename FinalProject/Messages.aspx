<%@ Page Title="" Language="C#" MasterPageFile="~/ContentTemplate.master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="FinalProject.WebForm2" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <link href="content/css/message.css" rel="stylesheet" type="text/css">
    <script runat="server">
        protected void ImageButton1_Load(object sender, EventArgs e)
        {
            try
            {
                AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
                LinkButton linkButton = (LinkButton)sender;
                trigger.ControlID = linkButton.UniqueID;
                trigger.EventName = "UsersListView_SelectedIndexChanged";
                this.pnlMessages.Triggers.Add(trigger);
            }
            catch
            {

            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    <h1 class="h3 mb-0 text-gray-800">Messages</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="pnlMessages" class="col-md-12 p-0" runat="server">
        <ContentTemplate>
            <div id="frame" class="col-md-12 p-0">
                <div id="sidepanel">
                    <div id="profile">
                        <div class="wrap">
                            <img id="profile-img" src="Uploads/<%= user.Image %>" class="online" alt="" />
                            <p><%= user.FirstName %> <%= user.LastName %></p>
                            <i class="fa fa-chevron-down expand-button" aria-hidden="true"></i>
                        </div>
                    </div>
                    <div id="contacts">
                        <ul>
                            <asp:ListView ID="lvContacts" AutoPostBack="true" runat="server" OnSelectedIndexChanging="UsersListView_SelectedIndexChanging" OnSelectedIndexChanged="UsersListView_SelectedIndexChanged">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" CommandName="Select" runat="server" OnLoad="ImageButton1_Load">
                                        <li class="contact">
                                            <div class="wrap">
						                        <img src="Uploads/<%# Eval("UserImage")  %>" alt="" />
						                        <div class="meta">
							                        <p class="name"><%# Eval("UserFirstName")  %> <%# Eval("UserLastName")  %></p>
							                        <p class="preview"><%# Eval("ProductName")  %></p>
						                        </div>
					                        </div>
				                        </li>
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <SelectedItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" CommandName="Select" runat="server" OnLoad="ImageButton1_Load">
                                        <li class="contact active">
                                            <div class="wrap">
						                        <img src="Uploads/<%# Eval("UserImage")  %>" alt="" />
						                        <div class="meta">
							                        <p class="name"><%# Eval("UserFirstName")  %> <%# Eval("UserLastName")  %></p>
							                        <p class="preview"><%# Eval("ProductName")  %></p>
						                        </div>
					                        </div>
				                        </li>
                                    </asp:LinkButton>
                                </SelectedItemTemplate>
                            </asp:ListView>
                        </ul>
                    </div>
                    <%if (!user.IsCompany)
                        {%>
                    <div id="bottom-bar">
                        <asp:LinkButton ID="btnBuyer" runat="server" OnClick="btnBuyer_Click"><span>Selling Products</span></asp:LinkButton>
                        <asp:LinkButton ID="btnSeller" runat="server" OnClick="btnSeller_Click"><span>Buying Products</span></asp:LinkButton>
                    </div>
                    <%} %>
                </div>
                <div class="content">
                    <div class="contact-profile">
                        <img id="ToUserImage" runat="server" src="Uploads/defaultUser.png" alt="" />
                        <p id="chatUser" runat="server"></p>
                    </div>
                    <div class="messages">
                        <ul>
                            <asp:ListView ID="lvMessage" AutoPostBack="true" runat="server" OnSelectedIndexChanging="UsersListView_SelectedIndexChanging" OnSelectedIndexChanged="UsersListView_SelectedIndexChanged">
                                <ItemTemplate>
                                    <li class="<%# Eval("isSender").ToString().ToUpper() == "TRUE" ? "sent" : "replies" %>">
                                        <img src="Uploads/<%# Eval("UserImage") %>" alt="" />
                                        <p><%# Eval("MessageText") %></p>
                                    </li>
                                </ItemTemplate>
                            </asp:ListView>
                        </ul>
                    </div>
                    <div class="message-input">
                        <div class="wrap">
                            <asp:TextBox ID="txtMessage" runat="server" placeholder="Enter your message"></asp:TextBox>
                            <asp:LinkButton ID="btnSendMessage" CssClass="submit" runat="server" OnClick="btnSendMessage_Click"><i class="fa fa-paper-plane" aria-hidden="true"></i></asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
