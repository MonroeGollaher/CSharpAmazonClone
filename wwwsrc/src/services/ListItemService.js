import { logger } from '../utils/Logger'
import { api } from './AxiosService'
import { AppState } from '../AppState'

class ListItemsService {
  async addItemToList(listItem) {
    try {
      await api.post('api/listitems', listItem)
      console.log(listItem)
      this.getAllListItems()
    } catch (error) {
      logger.error(error)
    }
  }

  async getAllListItems() {
    try {
      const res = await api.get('api/listitems')
      AppState.listItems = res.data
    } catch (error) {
      logger.error(error)
    }
  }
}

export const listItemsService = new ListItemsService()
