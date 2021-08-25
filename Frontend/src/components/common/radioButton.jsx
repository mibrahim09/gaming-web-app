import React, { Component } from 'react'
import { NavLink } from 'react-router-dom'
class RadioButton extends Component {
  state = {}
  render() {
    const { id, label, onClick } = this.props
    return (
      <NavLink
        className="btn btn-outline-dark"
        to={() => {
          return `/ranks/${id}`
        }}
      >
        {label}
      </NavLink>
    )
  }
}

export default RadioButton
