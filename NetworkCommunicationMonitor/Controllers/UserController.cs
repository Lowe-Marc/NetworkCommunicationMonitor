using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NetworkCommunicationMonitor.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // This will determine whether the credentials match what the database has for the username.
        // If they match, the user will be redirected to the question page, otherwise they will
        // be prompted the credentials are incorrect and can try logging in again.
        [HttpPost]
        public ActionResult Login(Models.User user)
        {
            if (ModelState.IsValid)
            {
                string valid = user.IsValid(user.UserName, user.Password);
                if (valid.Equals("true", StringComparison.Ordinal))
                {
                    Session["adminID"] = user.getID();
                    Session["user"] = user;
                    Session["username"] = user.UserName;
                    return RedirectToAction("Question", "User");
                }
                else if (valid.Equals("blocked",StringComparison.Ordinal))
                {
                    return RedirectToAction("Blocked", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // This will gather the questions to ask the user. They are already in random order.
        // If there are no more questions to ask the user, they will be blocked and redirected to
        // the homepage.
        [HttpGet]
        public ActionResult Question()
        {
            if (Models.Global.questions.Count == 0)
            {
                Models.User.blockThisUser(Convert.ToInt32(Session["adminID"]));
                Session["adminID"] = null;
                return RedirectToAction("Blocked", "Home");
            }
            ViewData["Question"] = Models.Global.questions.Pop();

            return View();
        }

        // This validates whether or not the answer provided by the user is correct
        // Note that we should never hit the case where the correctAnswers stack is empty,
        // as that means they would have exhausted all the questions and been blocked/redirected.
        [HttpPost]
        public ActionResult ValidateQuestion(Models.User user)
        {
            string answer = Models.Global.correctAnswers.Pop();
            if (user.answerProvided.Equals(answer,StringComparison.Ordinal))
            {
                return RedirectToAction("Homepage", "Home");
            }

            return RedirectToAction("Question", "User", user);
        }

        [HttpGet]
        public ActionResult ViewAccounts(Models.User user)
        {

            return View();
        }
    }
}