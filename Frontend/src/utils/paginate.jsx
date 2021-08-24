import _ from 'lodash'

export function paginate(items, pageNumber, pageSize) {
  const startIndex = (pageNumber - 1) * pageSize

  // we need to convert items to lodash wrapper _(items)
  return _(items).slice(startIndex).take(pageSize).value()
}
