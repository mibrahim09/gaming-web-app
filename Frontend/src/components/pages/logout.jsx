import React, { Component } from 'react'
import AuthService from '../../services/authService'

class Logout extends Component {
  componentDidMount() {
    AuthService.removeJwt()
    window.location = '/'
  }
  render() {
    return <div></div>
  }
}

export default Logout
