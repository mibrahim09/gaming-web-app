import React, { Component } from 'react'
import { Container, Row, Col } from 'react-bootstrap'
import { Link } from 'react-router-dom'
import RadioButton from '../common/radioButton'
import config from '../../config.json'
import axios from 'axios'
import { paginate } from '../../utils/paginate'
import Pagination from '../common/pagination'
class Ranks extends Component {
  state = {
    rankType: 'NONE',
    rankList: [],
    currentPage: 1,
    pageSize: 5,
  }

  apiEndPoint = config.apiEndPoint + 'Statistics/'
  async componentDidMount() {
    const rankType = this.props.match.params.rankType
    console.log('RankType=', rankType)

    const results = await axios.get(this.apiEndPoint + rankType)

    this.setState({
      rankType: rankType,
      rankList: results.data,
      currentPage: 1,
    })
  }
  async componentDidUpdate(prevProps, prevState) {
    const rankType = this.props.match.params.rankType
    if (rankType != prevState.rankType) {
      const results = await axios.get(this.apiEndPoint + rankType)
      this.setState({
        currentPage: 1,
        rankType: rankType,
        rankList: results.data,
      })
    }
  }

  handleChangePage = (page) => {
    this.setState({ currentPage: page })
  }
  handleSwitchClass(classType) {}
  render() {
    const { rankList, currentPage, pageSize } = this.state
    const ranksToShow = paginate(rankList, currentPage, pageSize)

    return (
      <Container className="mt-5">
        <Row>
          <Col xs={2}>
            <div class="btn-group-vertical">
              <RadioButton id="Trojan" label="Trojans" />
              <RadioButton id="Archer" label="Archers" />
              <RadioButton id="Fire" label="Fire Taoist" />
              <RadioButton id="Water" label="Water Taoist" />
              <RadioButton id="Warrior" label="Warrior" />
            </div>
          </Col>
          <Col xs={10}>
            {rankList.length == 0 && (
              <h3>There are no ranks to show in this category.</h3>
            )}
            {rankList.length != 0 && (
              <table className="table">
                <thead>
                  <tr>
                    <th scope="col">Name</th>
                    <th scope="col">Level</th>
                    <th scope="col">Potency</th>
                    <th scope="col">Guild</th>
                  </tr>
                </thead>
                <tbody>
                  {ranksToShow.map((p) => (
                    <tr>
                      <td>{p.name}</td>
                      <td>{p.level}</td>
                      <td>{p.param}</td>
                      <td>{p.guildName}</td>
                    </tr>
                  ))}{' '}
                </tbody>
              </table>
            )}

            <Pagination
              itemsCount={rankList.length}
              pageSize={this.state.pageSize}
              onPageChange={this.handleChangePage}
              currentPage={this.state.currentPage}
            ></Pagination>
          </Col>
        </Row>
      </Container>
    )
  }
}

export default Ranks
