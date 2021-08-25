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
        this.setState(data)
      }
    } catch {}
  }
  handleChangePage = (page) => {
    this.setState({ currentPage: page })
  }
  render() {
    const {
      transactions,
      currentPage,
      pageSize,
      account,
      character,
    } = this.state
    const transactionsToShow = paginate(transactions, currentPage, pageSize)
    return (
      <Container>
        {character && (
          <div className="mb-5">
            <h3 className="mb-3 fw-light text-muted">Character Info</h3>

            <div className="m-3">
              <Row className="mb-2">
                <Col xs={2}>
                  Name: <span style={{ color: 'green' }}>{character.name}</span>
                </Col>
                <Col xs={2}>
                  Spouse:{' '}
                  <span style={{ color: 'green' }}>{character.spouse}</span>
                </Col>

                <Col xs={2}>
                  Status: {' '}
                  {account.isOnline ? (
                    <span style={{ color: 'green' }}>ONLINE</span>
                  ) : (
                    <span style={{ color: 'red' }}>OFFLINE</span>
                  )}
                </Col>
              </Row>
              <Row className="mb-2">
                <Col xs={2}>
                  Silvers:{' '}
                  <span style={{ color: 'green' }}>{character.silvers}</span>
                </Col>
                <Col xs={2}>
                  Level:{' '}
                  <span style={{ color: 'green' }}>{character.level}</span>
                </Col>
                <Col xs={2}>
                  Vote Points:{' '}
                  <span style={{ color: 'green' }}>{character.votePoints}</span>
                </Col>
              </Row>
              <Row className="mb-2">
                <Col xs={2}>
                  VIP:{' '}
                  <span style={{ color: 'green' }}>
                    {character.vipLevel == null ? '0' : character.vipLevel}
                  </span>
                </Col>
                <Col xs={2}>
                  VIP Expiry:{' '}
                  <span style={{ color: 'green' }}>
                    {character.vipendDate == null
                      ? 'NONE'
                      : character.vipendDate}
                  </span>
                </Col>

                <Col xs={2}>
                  ConquerPoints:{' '}
                  <span style={{ color: 'green' }}>{character.cps}</span>
                </Col>
              </Row>
            </div>
          </div>
        )}
        {!character && (
          <h3 className="mb-3 fw-light text-muted ">No character yet</h3>
        )}
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
