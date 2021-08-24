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
      username: '',
      password: '',
    },
    errors: [],
    globalError: '',
    globalOK: '',
  }

  apiEndPoint = config.apiEndPoint + 'users/login'

  schema = Joi.object({
    username: Joi.string().required().max(12).min(4).label('Username'),
    password: Joi.string().required().min(4).max(12).label('Password'),
  })

  async doSubmit() {
    const { username, password } = this.state.data
    try {
      const result = await axios.post(this.apiEndPoint, this.state.data)
      console.log(result)
      if (result.status == 200) {
        const token = result.data

        AuthService.storeJWT(token)

        this.setState({
          globalOK: `You have successfully logged back in! You'll be redirected right now.`,
          globalError: '',
        })
        setTimeout(() => {
          window.location = '/'
        }, 1500)
      }
    } catch (ex) {
      this.setState({ globalError: ex.response.data.error, globalOK: '' })
    }
  }

  render() {
    const { globalError, globalOK } = this.state
    return (
      <Container>
        <h3 className="mb-5">Login</h3>
        {this.renderInput('username', 'Username')}
        {this.renderInput('password', 'Password', 'password')}
        {this.renderBtn('Login')}
        {globalError && (
          <div className="mt-3 alert alert-danger">{globalError}</div>
        )}
        {globalOK && <div className="mt-3 alert alert-success">{globalOK}</div>}
      </Container>
    )
  }
}

export default LoginForm
