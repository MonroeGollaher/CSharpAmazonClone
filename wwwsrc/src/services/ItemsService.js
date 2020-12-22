import { logger } from '../utils/Logger'
import { AppState } from '../AppState'
import { api } from './AxiosService'
class ItemsService {
  async getItems() {
    try {
      const res = await api.get('api/items')
      console.log(res.data)
      AppState.items = res.data
    } catch (error) {
      logger.error(error)
    }
  }

  async addItem(itemData) {
    try {
      await api.post('api/items', itemData)
      logger.log(itemData)
      this.getItems()
    } catch (error) {
      logger.error(error)
    }
  }

  async deleteItem(id) {
    try {
      await api.delete('/api/items/' + id)
      console.log('item deleted')
      this.getItems()
    } catch (error) {
      logger.error(error)
    }
  }
}
export const itemsService = new ItemsService()
