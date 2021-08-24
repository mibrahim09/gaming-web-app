import React, { Component } from 'react'
import Form from '../common/form'
import Joi from 'joi'
import { Container } from 'react-bootstrap'
import axios from 'axios'
import config from '../../config.json'
import AuthService from '../../services/authService'

class LoginForm extends Form {
  state = {
    data: {
      oldPassword: '',
      newPassword: '',
    },
    errors: [],
    globalError: '',
    globalOK: '',
  }

  apiEndPoint = config.apiEndPoint + 'profile/changepass'

  schema = Joi.object({
    oldPassword: Joi.string().required().min(4).max(12).label('Old Password'),
    newPassword: Joi.string().required().min(4).max(12).label('New Password'),
  })

  async doSubmit() {
    const { username, password } = this.state.data
    try {
      const result = await axios.post(this.apiEndPoint, this.state.data, {
        headers: {
          Authorization: AuthService.getJwt(), //the token is a variable which holds the token
        },
      })
      if (result.status == 200) {
        const token = result.data.value.token
        AuthService.storeJWT(token)
        console.log('TOKEN=', token)
        this.setState({
          globalOK: `You have successfully changed your password!`,
          globalError: '',
        })
      }
    } catch (ex) {
      this.setState({ globalError: ex.response.data, globalOK: '' })
    }
  }

  render() {
    const { globalError, globalOK } = this.state
    return (
      <Container>
        <h3 className="mb-5">Change Password</h3>
        {this.renderInput('oldPassword', 'Old Password', 'password')}
        {this.renderInput('newPassword', 'New Password', 'password')}
        {this.renderBtn('Change Password')}
        {globalError && (
          <div className="mt-3 alert alert-danger">{globalError}</div>
        )}
        {globalOK && <div className="mt-3 alert alert-success">{globalOK}</div>}
      </Container>
    )
  }
}

export default LoginForm
