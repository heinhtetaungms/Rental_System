using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_System.rental_system.session
{
    class SessionManager //singleton, responsible for managing the session object.
    {
        private static SessionManager instance;
        private Session currentSession;
        private List<ApplianceSession> applianceSessions;
        private SessionManager() {
            applianceSessions = new List<ApplianceSession>();
        }

        public static SessionManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new SessionManager();
                    return instance;
            }
        }

        public Session CurrentSession
        {
            get { return currentSession; }
            set { currentSession = value; }
        }

        public void InvalidateSession()
        {
            currentSession = null;
        }

        public List<ApplianceSession> CurrentApplianceSessions 
        {
            get { return applianceSessions; }
        }
        public void AddApplianceSession(ApplianceSession applianceSession)
        {
            applianceSessions.Add(applianceSession);
        }
        public void RemoveApplianceSession(ApplianceSession applianceSession)
        {
            applianceSessions.Remove(applianceSession);
        }

        public void ClearApplianceSessions()
        {
            applianceSessions.Clear();
        }
    }
}
