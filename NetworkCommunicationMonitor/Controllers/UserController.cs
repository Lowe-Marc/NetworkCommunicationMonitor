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
                if (user.IsValid(user.UserName, user.Password))
                {
                    return RedirectToAction("Question", "User", user);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Login credentials are incorrect!");
                    return RedirectToAction("Login", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // This will gather the questions to ask the user. They are already in random order.
        // If there are no more questions to ask the user, they will be blocked and redirected to
        // the homepage.
        [HttpGet]
        public ActionResult Question(Models.User user)
        {
            if (Models.Global.questions.Count == 0)
            {
                user.blockThisUser();
                return RedirectToAction("Index", "Home");
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
                //FormsAuthentication.SetAuthCookie(user.UserName, user.RememberMe);
                HttpCookie loggedinCookie = new HttpCookie("LoggedIn", user.UserName);
                loggedinCookie.Expires = DateTime.Now.AddHours(12); // TODO: Find a better way to do this
                Response.Cookies.Add(loggedinCookie);
                return RedirectToAction("Index", "Home");
            }

            return Question(user);
        }

        [HttpGet]
        public ActionResult ViewAccounts(Models.User user)
        {

            return View();
        }
    }
}