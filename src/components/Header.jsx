import React, { useContext, useState } from "react";
import Logo from "../images/codepenAI.png";
import { CurrentUserContext } from "../functions/contexts";
import PasswordInput from "password-input-component";
import { RegisterUser, getMe, loginUser, logout } from "../APIs/API";

export default function Header() {
  const { currentUser, setCurrentUser } = useContext(CurrentUserContext);
  const [showLoginForm, setShowLoginForm] = useState(false);
  const [showRegisterForm, setShowRegisterForm] = useState(false);
  const [showLogoutButton, setShowLogoutButton] = useState(false);
  const [loginEmail, setLoginEmail] = useState("");
  const [loginPassword, setLoginPassword] = useState("");
  const [registerEmail, setRegisterEmail] = useState("");
  const [registerPassword, setRegisterPassword] = useState("");

  const handleUserOptionsClick = () => {
    if (currentUser.email && currentUser.email.length > 0) {
      setShowLogoutButton(!showLogoutButton);
    } else {
      setShowLoginForm(!showLoginForm);
      setShowRegisterForm(false);
    }
    console.log(currentUser);
  };

  const handleNewHereClick = () => {
    setShowLoginForm(false);
    setShowRegisterForm(true);
  };

  const handleRegisterSubmit = (e) => {
    e.preventDefault();
    if (registerEmail.length > 0 && registerPassword.length > 0) {
      const props = { registerEmail, registerPassword };
      RegisterUser(props);
      setShowLoginForm(true);
      setShowRegisterForm(false);
    }
  };

  const handleLoginSubmit = async (e) => {
    e.preventDefault();
    if (loginEmail.length > 0 && loginPassword.length > 0) {
      const props = { loginEmail, loginPassword };
      loginUser(props);
      setShowLoginForm(false);
      setShowRegisterForm(false);
      const me = await getMe();
      setCurrentUser(me);
    }
  };

  const handleLogoutClick = async () => {
    logout();
    setCurrentUser({});
    setShowLogoutButton(false);
    setShowLoginForm(false);
    setShowRegisterForm(false);
  };

  return (
    <>
      <div className="header-wrapper">
        <div></div>
        <div className="title-wrapper">
          <img className="header-logo" src={Logo} alt="Logo" />
          <h1 className="header-title">CodepenAI</h1>
        </div>
        <div className="user-options">
          <button className="login-button" onClick={handleUserOptionsClick}>
            {currentUser.email ? currentUser.email : "Login"}
          </button>
          {showLoginForm && (
            <form className="login-form" onSubmit={(e) => handleLoginSubmit(e)}>
              <input
                type="text"
                placeholder="email"
                required
                onChange={(e) => setLoginEmail(e.target.value)}
              />
              <input
                type="password"
                placeholder="Password"
                required
                onChange={(e) => setLoginPassword(e.target.value)}
              />
              <button type="submit" className="submit-button">
                Login
              </button>
              <p>
                New here?{" "}
                <button
                  onClick={handleNewHereClick}
                  className="new-here-button"
                >
                  Register
                </button>
              </p>
            </form>
          )}
          {showRegisterForm && (
            <form
              className="register-form"
              onSubmit={(e) => handleRegisterSubmit(e)}
            >
              <input
                type="text"
                placeholder="email"
                required
                onChange={(e) => setRegisterEmail(e.target.value)}
              />
              <PasswordInput
                inputPlaceholder="Password"
                onInputChange={(e) => setRegisterPassword(e.target.value)}
              />
              <button type="submit" className="submit-button">
                Register
              </button>
            </form>
          )}
          {showLogoutButton && (
            <form>
              <button className="submit-button" onClick={handleLogoutClick}>
                Logout
              </button>
            </form>
          )}
        </div>
      </div>
    </>
  );
}
