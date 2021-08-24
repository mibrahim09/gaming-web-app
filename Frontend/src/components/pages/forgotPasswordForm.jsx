import React, { Component } from 'react'
import Form from '../common/form'
import Joi from 'joi'
import { Container } from 'react-bootstrap'

class ForgotPasswordForm extends Form {
  state = {
    data: {
      username: '',
      email: '',
    },
    errors: [],
  }

  schema = Joi.object({
    username: Joi.string().required().max(12).min(4).label('Username'),
    email: Joi.string()
      .required()
      .email({ minDomainSegments: 2, tlds: { allow: ['com', 'net'] } })
      .label('Email Address'),
  })

  doSubmit() {
    const { username, password } = this.state.data
    console.log(`Username:${username} -> Password:${password}`)
  }

  render() {
    return (
      <Container>
        <h3 className="mb-5">Register</h3>
        {this.renderInput('username', 'Username')}
        {this.renderInput('email', 'Email', 'email')}
        {this.renderBtn('Send Email')}
      </Container>
    )
  }
}

export default ForgotPasswordForm
