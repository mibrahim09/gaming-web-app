import React, { Component } from 'react'

import { NavLink, Link } from 'react-router-dom'
const CustomNavLink = (props) => {
  return (
    <div className="nav-item">
      <NavLink to={props.to} className="nav-link">
        {props.children}
      </NavLink>
    </div>
  )
}

const CustomNavDropDownLink = (props) => {
  return (
    <Link to={props.to} className="dropdown-item">
      {props.children}
    </Link>
  )
}

export { CustomNavLink, CustomNavDropDownLink }
