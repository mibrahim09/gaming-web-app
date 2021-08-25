import React, { Component } from 'react'
import Form from '../common/form'
import Joi from 'joi'
import { Container } from 'react-bootstrap'
import axios from 'axios'
import config from '../../config.json'
import AuthService from '../../services/authService'

class RegisterForm extends Form {
  state = {
    data: {
      username: '',
      password: '',
      confirmPassword: '',
      email: '',
    },
    errors: [],
    globalError: '',
    globalOK: '',
  }

  apiEndPoint = config.apiEndPoint + 'users/register'

  schema = Joi.object({
    username: Joi.string().required().max(12).min(4).label('Username'),
    password: Joi.string().required().max(12).min(4).label('Password'),
    confirmPassword: Joi.string().required(), //.valid(Joi.ref('password')),
    email: Joi.string()
      .required()
      .email({ minDomainSegments: 2, tlds: { allow: ['com', 'net'] } })
      .label('Email Address'),
  })

  async doSubmit() {
    const { username, password } = this.state.data
    try {
      const result = await axios.post(this.apiEndPoint, this.state.data)
      if (result.status == 200) {
        const token = result.data

        this.setState({
          globalOK: `You have successfully registered!`,
          globalError: '',
        })
      }
    } catch (ex) {
      this.setState({ globalError: ex.response.data.error, globalOK: '' })
    }
  }

  render() {
    const { globalError, globalOK } = this.state
    return (
      <Container>
        <h3 className="mb-5">Register</h3>
        {this.renderInput('username', 'Username')}
        {this.renderInput('password', 'Password', 'password')}
        {this.renderInput('confirmPassword', 'Confirm Password', 'password')}
        {this.renderInput('email', 'Email', 'email')}
        {this.renderBtn('Register')}
        {globalError && (
          <div className="mt-3 alert alert-danger">{globalError}</div>
        )}
        {globalOK && <div className="mt-3 alert alert-success">{globalOK}</div>}
      </Container>
    )
  }
}

export default RegisterForm
