<template>
  <div class="new-item-component container-fluid">
    <button class="btn border-0 rounded" data-toggle="modal" data-target="#newItemModal">
      <p class="text-dark ">
        Add Item<i class="fas fa-plus ml-3 text-success"></i>
      </p>
    </button>
    <div class="modal" tabindex="-1" id="newItemModal">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">
              Post an item
            </h5>
            <button type="button" class="btn-close bg-transparent border-0 text-danger" data-bs-dismiss="modal" aria-label="Close">
              <i class="far fa-times-circle"></i>
            </button>
          </div>
          <form @submit.prevent="addItem" class="p-2">
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
              <input type="text" class="form-control" placeholder="Picture" v-model="state.newItem.image">
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
            <div class="row justify-content-center">
              <label for="image">Published?</label>
              <input class="ml-3 p-2 m-1" type="checkbox" v-model="state.newItem.isAvailable">
            </div>
            <div class="row justify-content-center">
              <button type="submit" class="btn btn-primary text-light radius15 p-2">
                Add Item
                <i class="fas fa-check ml-2"></i>
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
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
