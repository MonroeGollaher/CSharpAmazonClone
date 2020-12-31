import { logger } from '../utils/Logger'
import { api } from './AxiosService'
import { AppState } from '../AppState'

class ListItemsService {
  async addItemToList(listItem) {
    try {
      await api.post('api/listitems', listItem)
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

  async getActiveListItems(listId) {
    try {
      const res = await api.get('api/lists/' + listId + '/listItems')
      AppState.activeListItems = res.data
    } catch (error) {
      logger.error(error)
    }
  }

  async removeFromList(itemId, listItemId) {
    try {
      await api.delete('api/listitems/' + listItemId)
      const item = AppState.activeListItems.findIndex(i => i.id === itemId)
      AppState.activeListItems.splice(item, 1)
    } catch (error) {
      logger.error(error)
    }
  }
}

export const listItemsService = new ListItemsService()
