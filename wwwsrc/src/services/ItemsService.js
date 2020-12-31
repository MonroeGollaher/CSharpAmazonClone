import { logger } from '../utils/Logger'
import { AppState } from '../AppState'
import { api } from './AxiosService'
class ItemsService {
  async getItems() {
    try {
      const res = await api.get('api/items')
      AppState.items = res.data
    } catch (error) {
      logger.error(error)
    }
  }

  async getUserItems() {
    try {
      // @ts-ignore
      const res = await api.get(`profile/${AppState.profile.id}/items`)
      AppState.myItems = res.data
    } catch (error) {
      logger.error(error)
    }
  }

  async addItem(itemData) {
    try {
      await api.post('api/items', itemData)
      this.getItems()
    } catch (error) {
      logger.error(error)
    }
  }

  async deleteItem(id) {
    try {
      await api.delete('/api/items/' + id)
      this.getItems()
    } catch (error) {
      logger.error(error)
    }
  }

  async editItem(editData, id) {
    try {
      await api.put('api/items/' + id, editData)
      this.getItems()
    } catch (error) {
      logger.error(error)
    }
  }

  async setActiveItem(itemId) {
    try {
      const res = await api.get('api/items/' + itemId)
      AppState.activeItem = res.data
    } catch (error) {
      logger.error(error)
    }
  }
}
export const itemsService = new ItemsService()
