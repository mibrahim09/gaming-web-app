import React, { Component } from 'react'
import _ from 'lodash'
class Pagination extends Component {
  render() {
    const { itemsCount, pageSize, currentPage } = this.props
    const pageCount = Math.ceil(itemsCount / pageSize)
    if (pageCount === 1) return null
    const itemsList = _.range(1, pageCount + 1)

    return (
      <nav aria-label="...">
        <ul className="pagination">
          {itemsList.map((item) => (
            <li
              key={item}
              className={item == currentPage ? 'page-item active' : 'page-item'}
            >
              <a
                className="page-link"
                onClick={() => this.props.onPageChange(item)}
              >
                {item}
              </a>
            </li>
          ))}
        </ul>
      </nav>
    )
  }
}

export default Pagination
