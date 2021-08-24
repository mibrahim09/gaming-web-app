import logo from './logo.svg'
import './App.css'
import AuthService from './services/authService'
import { BrowserRouter, Route, Switch } from 'react-router-dom'
import 'bootstrap/dist/css/bootstrap.css'
import 'font-awesome/css/font-awesome.min.css'
import LoginForm from './components/pages/loginForm'
import Logout from './components/pages/logout'
import RegisterForm from './components/pages/registerForm'
import ForgotPasswordForm from './components/pages/forgotPasswordForm'
import ChangePassForm from './components/pages/changePassForm'
import AboutUs from './components/pages/aboutUs'
import UserProfile from './components/pages/profile'
import Home from './components/pages/home'
import Downloads from './components/pages/downloads'
import Ranks from './components/pages/ranks'
import Footer from './components/common/footer'
import MyNavBar from './components/common/navBar'
import React, { Component } from 'react'

class App extends Component {
  state = {}
  componentDidMount() {
    try {
      const user = AuthService.getUserFromToken()
      this.setState({ user })
    } catch {}
  }

  render() {
    return (
      <div className="App">
        <BrowserRouter>
          <header>
            <MyNavBar user={this.state.user}></MyNavBar>
          </header>
          <main className="container mt-5">
            <Switch>
              <Route path="/team" component={AboutUs}></Route>
              <Route path="/ranks" component={Ranks}></Route>
              <Route path="/downloads" component={Downloads}></Route>
              <Route path="/user/login" component={LoginForm}></Route>
              <Route path="/user/logout" component={Logout}></Route>
              <Route path="/user/profile" component={UserProfile}></Route>
              <Route path="/user/changepass" component={ChangePassForm}></Route>
              <Route path="/user/register" component={RegisterForm}></Route>
              <Route
                path="/user/forgotpassword"
                component={ForgotPasswordForm}
              ></Route>
              <Route path="/" exact component={Home}></Route>
            </Switch>
          </main>
        </BrowserRouter>
        <Footer />
      </div>
    )
  }
}

export default App
