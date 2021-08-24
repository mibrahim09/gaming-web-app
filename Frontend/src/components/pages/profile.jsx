import React, { Component } from 'react'
import { Container, Row, Col } from 'react-bootstrap'
import axios from 'axios'
import config from '../../config.json'
import AuthService from '../../services/authService'
import { paginate } from '../../utils/paginate'
import Pagination from '../common/pagination'
class UserProfile extends Component {
  apiEndPoint = config.apiEndPoint + 'profile'
  state = {
    account: {},
    character: {},
    transactions: [],
    currentPage: 1,
    pageSize: 4,
  }
  async componentDidMount() {
    try {
      const result = await axios.get(this.apiEndPoint, {
        headers: {
          Authorization: AuthService.getJwt(), //the token is a variable which holds the token
        },
      })
      if (result.status == 200) {
        const data = result.data.value
        console.log(data);
        this.setState(data)
      }
    } catch {}
  }
  handleChangePage = (page) => {
    this.setState({ currentPage: page })
  }
  render() {
    const { transactions, currentPage, pageSize } = this.state
    const transactionsToShow = paginate(transactions, currentPage, pageSize)
    return (
      <Container>
        <Row>
          {transactions.length != 0 && (
            <Col xs={10}>
              <h3 className="mb-3 fw-light text-muted ">Transaction History</h3>

              <table className="table">
                <thead>
                  <tr>
                    <th scope="col">Item Name</th>
                    <th scope="col">Date</th>
                    <th scope="col">Price</th>
                    <th scope="col">Payment Status</th>
                    <th scope="col">Claimed</th>
                  </tr>
                </thead>
                <tbody>
                  {transactionsToShow.map((tx) => (
                    <tr>
                      <td>{tx.itemName}</td>
                      <td>{tx.date}</td>
                      <td>{tx.paymentGross}</td>
                      <td>{tx.paymentStatus}</td>
                      <td>{tx.claimed == 1 ? 'Yes' : 'No'}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
              <Pagination
                itemsCount={transactions.length}
                pageSize={this.state.pageSize}
                onPageChange={this.handleChangePage}
                currentPage={this.state.currentPage}
              ></Pagination>
            </Col>
          )}
        </Row>
      </Container>
    )
  }
}

export default UserProfile
