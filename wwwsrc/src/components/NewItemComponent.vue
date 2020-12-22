<template>
  <div class="new-item-component card shadow rounded">
    <h2>New Item</h2>
    <form @submit.prevent="addItem">
      <div class="form-group">
        <label for="itemTitle">Product title</label>
        <input type="text"
               class="form-control"
               id="itemTitle"
               aria-describedby="itemTitle"
               placeholder="What's your item called?"
               v-model="state.newItem.title"
        >
      </div>
      <div class="form-group">
        <label for="itemDescription">Description</label>
        <input type="text"
               class="form-control"
               id="itemDescription"
               placeholder="How would your describe your product?"
               v-model="state.newItem.body"
        >
      </div>
      <div class="form-group">
        <label for="image">Image</label>
        <input type="text" placeholder="Picture" v-model="state.newItem.image">
      </div>
      <div class="form-group">
        <label for="price">Price</label>
        <input type="number"
               class="form-control"
               id="itemPrice"
               placeholder="How much does your item cost?"
               v-model="state.newItem.price"
        >
      </div>
      <div class="form-group">
        <label for="price">Sale Price</label>
        <input type="number"
               class="form-control"
               id="salePrice"
               placeholder="If your item goes on sale, how much will it cost?"
               v-model="state.newItem.salePrice"
        >
      </div>
      <div class="form-group">
        <label for="itemQuantity">Quantity</label>
        <input type="number"
               class="form-control"
               id="itemQuantity"
               placeholder="How many items do you have to sell?"
               v-model="state.newItem.quantity"
        >
      </div>
      <div class="form-group">
        <label for="image">Private?</label>
        <input class="ml-3" type="checkbox" v-model="state.newItem.isAvailable">
      </div>
      <button type="submit" class="btn btn-primary mb-3">
        Add Item
      </button>
    </form>
  </div>
</template>

<script>
import { itemsService } from '../services/ItemsService'
import { reactive } from 'vue'
export default {
  name: 'NewItemComponent',
  setup() {
    const state = reactive({
      newItem: {

      }
    })
    return {
      state,
      addItem() {
        itemsService.addItem(state.newItem)
        state.newItem = {}
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
